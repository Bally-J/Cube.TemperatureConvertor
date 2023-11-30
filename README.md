# Cube

Hi Team

As requested, an implementation for both a .NET Api (Created in .Net7) and an Angular App have been created.
The Api end points can be executed via Swagger.
To Run the Angular App execute "ng s"
No specific mention of how the audit trail was to be persisted, so I have opted to use Sqlite in this instance for this demo. A migration file is included. However, you will need to run "update-database" in the Package Manager Console to create an instance of the database locally.
Unit Tests and Integration Tests have also been included