docker build -t auth0-aspnetcore-mvc-silent-auth .
docker run -it -p 3000:3000 -e "ASPNETCORE_URLS=http://*:3000" auth0-aspnetcore-mvc-silent-auth