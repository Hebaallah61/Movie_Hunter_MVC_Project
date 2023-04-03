Movie Hunter Documentation 😀
Movie Hunter is a project of Model-View-Controller (MVC) architecture that aims to provide a movie streaming website with an admin dashboard. The project was developed by a team of six members, as follows:

Our Team :relaxed:
Hesham
Mohammed
Ahmed
Asmaa
Heba
Maha
Project Parts:
The project consists of five parts, which are as follows:

Project Structure
Database
Identity System
Admin dashboard
Movie Website
Part Details:
1. Project Structure:
The project is partitioned into areas and has a structured setup of program.cs services and middlewares to work with the project. Additionally, the appsettings.json file is used for configuration purposes, including connection strings, Facebook and Google API keys, and Stripe payment gateway.

The project is partitioned into Areas:

AdminDashBoard
Identity
Payment
User: interaction of the user with movies and series
Movies and Series area.
2. Database:
The team created the database schema, models, and context. They also implemented the Repository Pattern using C# interfaces and classes.

3. Identity System:
The team scaffolded the identity system and implemented a register system with normal user credentials. They also integrated external logins with Google and Facebook, created roles (admin and normal user), and applied the admin account without registration. The normal or external user is assigned to the Normaluser role, and they have the ability to edit their profile and delete their account.

4. Admin Dashboard:
The admin dashboard is accessible only by users with admin roles. The team created a dashboard for CRUD (Create, Read, Update, Delete) operations on movies, series, and episodes. They also implemented user role management (assigning, removing, and CRUD operations) and used the AdminDashboard Template. Custom data annotations and routing constraints were used.

5. Movie Website Features:
The movie website provides features that are accessible to authenticated users, as follows:

Users can choose among three plans (Basic, Premium, Pro) and use the Stripe API to mimic payment.
All movies, series, and episodes are displayed, and users can add a specific amount of movies based on their plan (Basic: 2 movies, Premium: 6 movies, Pro: Unlimited Movies).
Users can add movies and series to their watchlist and view favorite movies and series. Additionally, recommended movies based on the user's favorite category are displayed.
Users can watch movies and series episodes and download them if authenticated.
The website includes a News Page.
Custom error pages are implemented to handle 404 errors and unauthorized errors.
6. Web Site Deployment
The website was deployed on IIS.

That concludes the documentation for Movie Hunter.

