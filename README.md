# Система учета поставок


## Особенности

  - Язык разработки backend - c# (.NET Core)
  - Язык разработки fronend - TypeScrypt ([Angular](https://angular.io/))
  - CSS Framework [Angular Material](https://material.angular.io/)
  - СУБД - MS SQL

## Техническое описание
| Сборка | Назначение  | Описание  |
|--|--|--|
| EquipmentSupply.API |Web приложение  | |
| EquipmentSupply.DAL |Логика работы с СУБД | Контексты доступа,  |
| EquipmentSupply.Domain | Базовая логика решения | Модели и контракты  |
| EquipmentSupply.Domain.Impl | Реализация базовой логики решения | Реализация сервисов бизнес-логики  |
| frontend/eq-supply| Web клиент | ||

## Сборка Web клиента

- Установить [Node.js](https://nodejs.org/ "Node.js")
- Установить [angular-cli](https://cli.angular.io/ "angular-cli")
```
npm install -g @angular/cli
```
- Установить [nrwl](https://nrwl.io/nx "nrwl")
```
npm install -g @nrwl/schematics
```
```
cd .\frontend\eq-supply
npm install
npm run buid
```
