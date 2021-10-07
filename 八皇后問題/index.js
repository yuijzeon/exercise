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
        this.size = size;
        this.board = Game.getBoard(size);
    }

    get(x, y) {
        return this.board[x][y];
    }

    selectFreeCellsIndexFromColumn(col) {
        var indexs = [];
        for (var i = 0; i < this.size; i++) {
            if (this.get(col, i).isFree()) indexs.push({'x': col,'y': i});
        }
        return indexs;
    }
    
    getCopy() {
        var newGame = new Game(this.size);
        for (var i = 0; i < this.size; i++) {
            for (var j = 0; j < this.size; j++) {
                newGame.get(i, j).state = this.get(i, j).state;
            }
        }
        return newGame;
    }

    putQueenAt(x, y) {
        var copy = this.getCopy();
        for (var i = 0; i < this.size; i++) {
            for (var j = 0; j < this.size; j++) {
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

    draw() {
        var result = `${this.size} 皇后的一解:\n`;

        for (var j = 0; j < this.size; j++) {
            for (var i = 0; i < this.size; i++) {
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

    isEqual(targetGame) {
        var isEqual = true;
        for (var i = 0; i < this.size; i++) {
            for (var j = 0; j < this.size; j++) {
                if (this.get(i, j).isQueen() !== (targetGame.get(i, j).isQueen())) isEqual = false;
            }
        }
        return isEqual;
    }
}

function queenRow(oldGame, col) {
    var freeCells = oldGame.selectFreeCellsIndexFromColumn(col);

    for (var cellIndex of freeCells) {

        var newGame = oldGame.putQueenAt(cellIndex.x, cellIndex.y);

        //newGame.draw();

        var nextCol =  col + 1;
        
        if (nextCol == newGame.size) {
            /*
            var isFundamental = false;
            for (var fundamental of fundamentals) {
                if (newGame.isEqual(fundamental)) isFinded = true;
            }
            
            if (!isFundamental) {
            */
                newGame.draw();
                solutions.push(newGame);
            /*
            }
            solutions.push(newGame);
            */
        }
        else {
            queenRow(newGame, nextCol);
        }
    }
}

var size = 1;

while(true){
    var myGame = new Game(size);
    var solutions = [];
    /*
    var fundamentals = [];
    */
    
    queenRow(myGame, 0);
    
    console.log(`${size} 皇后有 ${solutions.length} 種解`)
    size++
}