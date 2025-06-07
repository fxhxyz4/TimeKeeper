### Автоматичне очищення бд, після 00:01.
### Важливі записи можливо подивитсь через .log файли

```sql
CREATE EVENT IF NOT EXISTS daily_cleanup
ON SCHEDULE EVERY 1 DAY
STARTS TIMESTAMP(CURRENT_DATE + INTERVAL 1 DAY) + INTERVAL 1 MINUTE
DO
  DELETE FROM your_table WHERE date < CURDATE();
```
