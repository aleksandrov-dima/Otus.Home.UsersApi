# Otus.Home.UsersApi

## Команда установки PostgresSql:
helm install mypostgres bitnami/postgresql

## Команда создания конфига и секрета
kubectl apply -f .\Manifests\configmap.yml -f .\Manifests\secrets.yml

## Сборка образа джобы
docker build -f Dockerfile_job . -t dimandocker/otus.home.userapi.migratejob:1.0

## Командна публикации и запуска миграции
kubectl apply -f .\Manifests\migratejob.yml

## Команда публикации приложения:
kubectl apply -f .\Manifests\deployment_api.yml -f .\Manifests\service.yml