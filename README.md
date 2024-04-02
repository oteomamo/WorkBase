# WorkBase

WorkBase, developed using .NET framework, is a management platform tailored for recent college graduates, aiming to centralize and simplify job application and interview tracking. Its core boasts a versatile relational database system with User and Application entities, accommodating varied data storage needs, such as organizing challenges from LeetCode. Furthermore, it employs user-defined matrices for improved alerting and info management, ensuring a dynamic, customizable user experience.

## Features

Upon initialization, the system prompts the user to sign in or sign up, ensuring secure access to the application database. Once authenticated, users can view the current active application (if any) and the total number of applications they have access to. The primary interface serves as a portal where users can perform various CRUD (Create, Read, Update, Delete) operations on application data. Additionally, the AppView module provides a detailed view of specific application features and user access levels.

Structured with a tiered data hierarchy, the application allows users to navigate from user profiles to detailed application interfaces. Through a meticulously designed workflow, each application is inherently associated with a specific user, maintaining a strict one-to-many relationship hierarchy and ensuring data integrity.

When interacting with an application entity, users have the ability to modify application details or append user access levels to it. The user management component is equipped with a password verification feature, which, when activated, ensures that only authorized users can make changes to the application.

At the core of the system is a robust API service hosted locally, providing smooth interactions with the backend database. This backend is designed to efficiently manage and store data utilizing JSON files, ensuring quick retrieval and update operations. The system also provides users with the ability to sign in and sign out, enhancing security and user experience.

## Run and Test WorkBase

To execute the program, first install Visual Studio (VS) Community as the primary development environment. 
Before initializing the project, ensure that the following packages are installed:

1. ASP.NET and Web Development
2. Node.js Development
3. Mobile Development for .NET
4. .NET Desktop Development
5. Universal Windows Platform Development
6. Data Storage and Processing

<h3 align="left">Languages and Tools:</h3>
 <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://nodejs.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/nodejs/nodejs-original-wordmark.svg" alt="nodejs" width="40" height="40"/> </a> </p>
