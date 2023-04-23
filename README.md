# Otus.Home.UsersApi

Команда установки PostgresSql:
helm install mypostgres bitnami/postgresql

Командна публикации и запуска миграции
kubectl apply -f .\Manifests\migratejob.yml

Команда публикации приложения:
kubectl apply -f .\Manifests\deployment_api.yml -f .\Manifests\service.yml