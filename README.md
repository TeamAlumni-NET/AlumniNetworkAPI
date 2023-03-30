# AlumniNetworkAPI

AlumniNetworkAPi is back-end part of Alumni Network Portal. Its primary task is enable communication between Experis and Noroff Alumnis. 

With the Alumni Network Portal candidates are able to create and manage threads and comment them, create and join events, create and join topics and groups, see user details, display own activity on user dashboard.

AlumniNetworkApi is created with Entity Framework Code First workflow and ASP.NET Core in C#. It comprises a database made in SQL Server through EF Core
with a RESTful API to allow users to manipulate the data. 

## Technologies used

* .NET 6
* ASP.NET Core Web Api
* C#
* Microsoft SQL Server 19.0.1
* Microsoft SQL Server Management Studio
* Swagger
* Azure
* Docker

## Folder Structure
```
.
|   .dockerignore
|   .gitattributes
|   .gitignore
|   AlumniNetworkAPI.csproj
|   AlumniNetworkAPI.csproj.user
|   AlumniNetworkAPI.sln
|   appsettings.Development.json
|   appsettings.json
|   Dockerfile
|   Program.cs
|   README.md
|   
+---bin
|
+---Controllers
|       EventsController.cs			# Controller that communicates with EventService
|       EventUsersController.cs			# Controller that communicates with EventUserService
|       GroupsController.cs			# Controller that communicates with GroupService
|       PostsController.cs			# Controller that communicates with PostService
|       RsvpsController.cs			# Controller that communicates with RsvpService
|       TopicsController.cs			# Controller that communicates with TopicService
|       UsersController.cs			# Controller that communicates with UserService
|       
+---Exceptions					# Custom made exeptions
|       EventNotFoundException.cs		
|       PostNotFoundException.cs
|       UserAlreadyExistsException.cs
|       UserNotFoundException.cs
|       
+---Migrations					# Database migrations
|       20230329064826_InitialDb.cs
|       20230329064826_InitialDb.Designer.cs
|       AlumniNetworkDBContextModelSnapshot.cs
|       
+---Models					# Contains database tables and Dtos
|   |   AlumniNetworkDBContext.cs
|   |   
|   +---DTOs					# DTO´s of models
|   |   +---EventDtos
|   |   |       EventCalendarDto.cs
|   |   |       EventCreateDto.cs
|   |   |       EventDto.cs
|   |   |       EventNamesDto.cs
|   |   |       
|   |   +---EventUserDtos
|   |   |       EventUserDto.cs
|   |   |       
|   |   +---GroupDtos
|   |   |       CreateGroupUserDto.cs
|   |   |       GroupCreateDto.cs
|   |   |       GroupDto.cs
|   |   |       GroupUserDto.cs
|   |   |       
|   |   +---PostDtos
|   |   |       ChildPostDto.cs
|   |   |       ChildPostRootDto.cs
|   |   |       CreatePostDto.cs
|   |   |       EditPostDto.cs
|   |   |       NewPostDto.cs
|   |   |       PostByIdDto.cs
|   |   |       PostDto.cs
|   |   |       SimplePostDto.cs
|   |   |       TimelinePostDto.cs
|   |   |       
|   |   +---RsvpDtos
|   |   |       RsvpDto.cs
|   |   |       
|   |   +---TopicDtos
|   |   |       TopicCreateDto.cs
|   |   |       TopicDto.cs
|   |   |       TopicUserDto.cs
|   |   |       
|   |   \---UserDtos
|   |           UserCreateDto.cs
|   |           UserDto.cs
|   |           UserEditDto.cs
|   |           UserSimpleDto.cs
|   |           
|   \---Models					# Database tables
|           Event.cs
|           EventUser.cs
|           Group.cs
|           Post.cs
|           Rsvp.cs
|           Topic.cs
|           User.cs
|           
+---obj
+---Profiles					# Profiles for Automapper
|       EventProfile.cs
|       EventUser.cs
|       GroupProfile.cs
|       PostProfile.cs
|       RsvpProfile.cs
|       TopicProfile.cs
|       UserProfile.cs
|       
\---Services					# Queries for database tables				
    |   ICrudService.cs				
    |   
    +---Events
    |       EventService.cs
    |       IEventService.cs
    |       
    +---EventUsers
    |       EventUserService.cs
    |       IEventUserService.cs
    |       
    +---Groups
    |       GroupService.cs
    |       IGroupService.cs
    |       
    +---Posts
    |       IPostService.cs
    |       PostService.cs
    |       
    +---Rsvps
    |       IRsvpService.cs
    |       RsvpService.cs
    |       
    +---Topics
    |       ITopicService.cs
    |       TopicService.cs
    |       
    \---Users
            IUserService.cs
            UserService.cs
```

## Authors
[@Marco A](https://github.com/DeferredMonk)
[@Jesperi K](https://github.com/jespetius)
[@Heidi J](https://github.com/HeidiJoensuu)
[@Kirsi T](https://github.com/KipaTa)

## Sources
Project was an assignment done during education program created by Noroff Education
