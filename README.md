# ИС для сотрудников проката на Горнолыжном Курорте "Игора"
Выполнила Малышева Александра Юрьевна ИП 20-3

Скрипт для заполнения данными таблиц, находится в файлах проекта

## Диаграма Базы данных
![image](https://github.com/malbled/ProjectResort/assets/107112651/a4bf03cc-b9ce-47ef-ba52-1b8cbfe91468)

Диаграмма последовательности для прецендента Формирование заказа
---
```mermaid
sequenceDiagram
actor U as Staff
participant UI
participant CB as Code Behind
participant DB as Database
U->>UI:Добавление клиента
U->>UI:Добавление услуг
UI->>CB:Передача данных
CB->>CB:Проверка, что клиент и услуги выбраны
CB->>DB:Запись заказа
CB->>UI:Сообщение о успешности и вывод номера заказа

%%{init: {'theme': 'base', 'themeVariables': { 'primaryColor': '#b88fff', 'edgeLabelBackground':'#ffffee', 'tertiaryColor': '#fff0f0'}}}%%
```
