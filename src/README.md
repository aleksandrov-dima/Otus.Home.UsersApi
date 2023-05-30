# Otus.Home.UsersApi

## Команда установки PostgresSql:
```helm install mypostgres bitnami/postgresql```

## Команда создания конфига и секрета
```kubectl apply -f .\Manifests\configmap.yml -f .\Manifests\secrets.yml```

## Сборка образа джобы
```docker build -f Dockerfile_job . -t dimandocker/otus.home.userapi.migratejob:1.0```

## Командна публикации и запуска миграции
```kubectl apply -f .\Manifests\migratejob.yml```

## Сборка образа АПИ
```docker build -f .\Dockerfile_api . -t dimandocker/otus.home.userapi:1.0```

## Команда публикации приложения:
```kubectl apply -f .\Manifests\deployment_api.yml -f .\Manifests\service.yml -f .\Manifests\ingress.yml```

## Примеры запроса
```curl --location --request GET 'http://localhost/api/v1/Users' --header 'Host: arch.homework'```
```curl --location --request GET 'http://localhost/health' --header 'Host: arch.homework'```