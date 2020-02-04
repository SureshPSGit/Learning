## Docker commands to run redis in master/replica mode

```dockerfile
docker run -p 6379:6379 --name redis-master -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
docker run -p 6380:6379 --name redis-replica --link redis-master:master -e REDIS_REPLICATION_MODE=slave -e REDIS_MASTER_HOST=master -e REDIS_MASTER_PORT_NUMBER=6379 -e REDIS_MASTER_PASSWORD= -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
```