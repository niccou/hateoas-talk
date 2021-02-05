# hateoas-talk

![Couverture de code](demo/tests/Webapi.Tests/Badges/badge_linecoverage.svg)

## Demo

### Outils

[Use code coverage for unit testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)

### Couverture du code par les tests

Dans le répertoire de test

```bash
dotnet test --collect:"XPlat Code Coverage"
```

Reporting html

```bash
reportgenerator.exe "-reports:TestResults\**\*.xml" "-targetdir:coveragereport" -reporttypes:Html
```

Badges

```bash
reportgenerator.exe "-reports:TestResults\**\*.xml" "-targetdir:Badges" -reporttypes:Badges
```