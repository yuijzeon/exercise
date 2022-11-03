# TWTG Katas:

https://paper.dropbox.com/doc/TWTG-Kata-cYkQu4JJDnU8K87jafyU2

# Tennis Kata

# Budget Kata

這是你需要完成的 API：

* ```decimal BudgetService.Query(DateTime start, DateTime end)```

當有人使用此 API 時，要回傳 start 到 end 區間的總預算是多少

這是你可以調用的 API：

* ```List<Budget> IBudgetRepository.GetAll()```

已知：

1. `Query` 傳入的時間以天為單位
2. `Budget`有兩個欄位
    1. `string YearMonth`(格式為`yyyyMM`) 這個欄位被當作主鍵
    2. `int Amount` 這個欄位記錄了該月的整月預算

# Match Kata

這是你需要完成的 API：

* Http Method: `[POST]`或`[PATCH]`
* End Point: ```/Match/UpdateGoalRecord```
* 會同時傳入 `int id` 和 `string soccerEvent`

當有人使用此 API 時，要更新資料庫裡對應 id 的 Match 資料

這是你可以調用的 API：

* `Match GetMatch(int id)`
* `void UpdateGoalRecord(Match match)`

已知：

1. `soccerEvent` 有四種
    1. `HomeGoal` 主隊得分
    2. `AwayGoal` 客隊得分
    3. `HomeCancel` 取消主隊得分
    4. `AwayCancel` 取消客隊得分
2. `Match`有三個欄位
    1. `int Id`(格式為`yyyyMM`) 這個欄位被當作主鍵
    2. `int LivePeriod` 1 或 2，決定上下半場
    3. `string GoalRecord` 要被更新的欄位，由三種字元組成
        * `H` 代表主隊得分
        * `A` 代表客隊得分
        * `;` 代表中場休息
        * `AAH;HAA` 代表 2:4 (主隊上下半場各得一分，客隊上下半場各得兩分)
3. 當 `Cancel` 事件被發起時，需要上一次得分的隊伍相同才能被取消，否則須拋出錯誤
    * `HAH` 不接受被 `AwayCancel`
4. 在下半場取消上半場的得分是被允取的
    * `HAH;` 是可以被 `HomeCancel` 成 `HA;` 的
5. `LivePeriod` 是另一個團隊做的 API 在控制，被更改時並不會在 `GoalRecord` 加上 `;`
