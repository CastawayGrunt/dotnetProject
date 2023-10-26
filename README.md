# dotnetProject

This project is to demonstrate ASP.NET abilities, with a store front.

It uses a Postgres database in a Docker container, which is set up using the following.

```sh
# In your shell
docker pull postgres:14-alpine

# The order of these arguments actually does matter
docker run --name postgres -v postgres_volume:/var/lib/postgresql/data -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -p 5432:5432 -d postgres:14-alpine
```
