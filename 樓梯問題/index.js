class Cell {
    constructor(state) {
        this.state = state;
    }

    isQueen() {
        if(this.state === 'queen') return true;
        return false;
    }

    isWarning() {
        if(this.state === 'warning') return true;
        return false;
    }

    isFree() {
        if(this.state === 'free') return true;
        return false;
    }

    setQueen() {
        this.state = 'queen';
        return this;
    }

    setWarning() {
        this.state = 'warning';
        return this;
    }
}

class Game {
    constructor(size) {
        this.board = Game.getBoard(size);
    }

    get(x, y) {
        return this.board[x][y];
    }

    getFreeCellsIndex() {
        var cellIndexs = [];
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                if (this.get(i, j).isFree()) cellIndexs.push({'x': i,'y': j});
            }
        }
        return cellIndexs;
    }

    getQueenCount(x, y) {
        var queenCount = 0;
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                if (this.get(i, j).isQueen()) queenCount++;
            }
        }
        return queenCount;
    }
    
    getCopy() {
        var newGame = new Game(size);
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                newGame.get(i, j).state = this.get(i, j).state;
            }
        }
        return newGame;
    }

    putQueenAt(x, y) {
        var copy = this.getCopy();
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                if (!copy.get(i, j).isFree()) continue;

                if (i === x && j === y) {
                    copy.get(i, j).setQueen();
                }
                else if (i === x || j === y || Math.abs(x - i) === Math.abs(y - j)) {
                    copy.get(i, j).setWarning();
                }
            }
        }
        return copy;
    }

    isNotFreeCell() {
        var allNotFree = true;
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                if (this.get(i, j).isFree()) allNotFree = false;
            }
        }
        return allNotFree;
    }

    draw() {
        var result = '';

        for (var j = 0; j < size; j++) {
            for (var i = 0; i < size; i++) {
                if (this.get(i, j).isQueen()) {
                    result += 'Ｑ';
                }
                else if (this.get(i, j).isWarning()) {
                    result += '．';
                }
                else {
                    result += 'Ｎ';
                }
            }
            result += '\n';
        }

        console.log(result);
    }

    static getBoard(size) {
        var board = [];
        for (var i = 0; i < size; i++) {
            var col = [];
            for (var j = 0; j < size; j++) {
                col[j] = new Cell('free');
            }
            board[i] = col;
        }
        return board;
    }

    static isEqual(aGame, bGame) {
        var isEqual = true;
        for (var i = 0; i < size; i++) {
            for (var j = 0; j < size; j++) {
                if (aGame.get(i, j).isQueen() !== (bGame.get(i, j).isQueen())) isEqual = false;
            }
        }
        return isEqual;
    }
}

var size = 7;
var myGame = new Game(size);
var solutions = [];

function queenQuestion(oldGame) {
    for (var index of oldGame.getFreeCellsIndex()) {
        if (oldGame.isNotFreeCell()) continue;

        var newGame = oldGame.putQueenAt(index.x, index.y);

        //newGame.draw();

        if (newGame.getQueenCount() === size) {

            //newGame.draw();

            var isFinded = false;
            for (var solution of solutions) {
                if (Game.isEqual(solution, newGame)) isFinded = true;
            }

            if (!isFinded) {
                newGame.draw();
                solutions.push(newGame);
            }
        }
        else queenQuestion(newGame);
    }
}

queenQuestion(myGame);

console.log(solutions.length)