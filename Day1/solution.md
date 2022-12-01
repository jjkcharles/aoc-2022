# Solution Using Excel

## Steps:
1. Copy **Input** into Column A
2. Apply formula `=COUNTIF(A$1:A2, "")` on 2nd row in Column B and fill it on rest of the rows
3. Apply formula `=SUMIF(B$1:B1,"="&B2-1,A$1:A1)` on 2nd row in Column C and fill it on rest of the rows
4. Filter by Column A with only those rows that have **(blank)** value
5. The filtered result is list of all the Elves along with their Total Calorie
6. Sort the list to identify Elf with most calories
7. Apply similar approach to identify and sum calorie carried by Top 3 Elves