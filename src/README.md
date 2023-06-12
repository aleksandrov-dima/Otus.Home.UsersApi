# Otus.Home.UsersApi

## Перейти в каталог src
```cd src```

## Команда установки PostgresSql:
```helm repo update```

``` helm install mypostgres bitnami/postgresql -f .\Manifests\values.yml```

## Команда создания конфига и секрета
```kubectl apply -f .\Manifests\configmap.yml -f .\Manifests\secrets.yml```

## Командна публикации и запуска миграции
```kubectl apply -f .\Manifests\migratejob.yml```

## Команда публикации приложения:
```kubectl apply -f .\Manifests\deployment_api.yml -f .\Manifests\service.yml -f .\Manifests\ingress.yml```

## Примеры запроса
```curl --location --request GET 'http://localhost/api/v1/Users' --header 'Host: arch.homework'```
```curl --location --request GET 'http://localhost/health' --header 'Host: arch.homework'```

## Тесты через newman
```newman run .\Otus.postman_collection.json```

## Удаление приложения
```kubectl delete service/otus-home-user-api-service deployment/otus-home-user-api-deployment ingress/otus-home-user-api-ingress job/otus-home-user-api-migratejob```