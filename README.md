# Trees of Data

In this task we will look into how we may need to optimize some SQL statements to be much faster.

## Guidance

1. Start this project in [Github Codespaces](https://github.com/features/codespaces)[^1]
   1. Open a new Codespace and point it to this directory
   2. Install extensions as required in your new codespace (e.g. SQL Server)
2. Start the the database with the initial dataset
   1. Start the db `docker compose up db` (wait until sqlserver manages to start, it may take time)
   2. Start the app `docker compose up app` (It will generate some test data one can look into, it may take time)[^2]
3. Have a look at the applications API Specification
   1. Open the application using the provided port-forwarding URL (a popup should have appeared after you start the docker container) and append `/swagger/index.html` to the URL
   
   `NOTE: the application only becomes available after it has finished seeding the DB with initial data. This may take some time!`
4. Read [the story](STORY.md)
5. Read the [notes](NOTES.md)

## Additional task

* Improve the performance

## Notes

* used techstack:
  * [Git](https://git-scm.com/)
  * [Github Codespaces](https://github.com/features/codespaces)
  * [SQL Server](https://www.microsoft.com/de-de/sql-server)
  * [mssql extension](https://learn.microsoft.com/en-us/sql/tools/visual-studio-code/mssql-extensions?view=sql-server-ver16)
  * [ASP.NET Core](https://learn.microsoft.com/de-de/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)

---

[^1]: It's where the `<> Code` button is

[^2]: You can track the progress using `docker logs -f` or `docker compose logs -f`
