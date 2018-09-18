# Система учета поставок


## Особенности

  - Язык разработки backend - c# (.NET Core)
  - Язык разработки frontend - TypeScript ([Angular](https://angular.io/))
  - CSS Framework [Angular Material](https://material.angular.io/)
  - СУБД - MS SQL
  - Тестирование - [Xunit](https://xunit.github.io/ "Xunit"), Mocking - [NSubstitution](http://nsubstitute.github.io/help/getting-started/ "NSubstitution")

## Техническое описание
| Сборка | Назначение  | Описание  |
|--|--|--|
| EquipmentSupply.API |Web приложение  | |
| EquipmentSupply.DAL |Логика работы с СУБД | Контексты доступа,  |
| EquipmentSupply.Domain | Базовая логика решения | Модели и контракты  |
| EquipmentSupply.Domain.Impl | Реализация базовой логики решения | Реализация сервисов бизнес-логики  |
| frontend/eq-supply| Web клиент | ||

## Тесты
|  Сборка  | Описание  |
| ------------ | ------------ |
|  test/API/EquipmentSupply.API.UnitTests | Тесты контроллеров API   |
| test/DAL/EquipmentSupply.DAL.UnitTests  | Тестирование UnityOfWork   |
| test/Domain/EquipmentSupply.Domain.Imp.UnitTests | Тестирование бизнес-логики приложения ||


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

## Сборка и запус Web приложения

- Установить [.NET Core](https://www.microsoft.com/net/download ".NET Core")
```
dotnet restore EquipmentSupply.API
dotnet build EquipmentSupply.API
dotnet EquipmentSupply.API
```
