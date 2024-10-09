# Student_Teacher_QnA_Platform

## Project Description
The **Student_Teacher_QnA_Platform** is a web-based application where students and teachers from various institutions can interact. Students can ask questions related to their studies, and teachers can respond by providing answers. The platform enables academic discussions and fosters collaboration between students and teachers.

## Technologies Used
- **ASP.NET Core MVC** (Model-View-Controller)
- **Entity Framework Core** (ORM for database interaction)
- **SQL Server** (Database)
- **C#** (Backend logic)
- **HTML/CSS** (Frontend design)
- **JavaScript** (Frontend interaction)

## Database Schema Overview

### Entities and Relationships:

1. **User**:
   - The `User` table stores the basic details of each user in the system, whether they are a student, teacher, or moderator.
   - **Fields**:
     - `ID`: The unique identifier for each user.
     - `User_Name`: The username used for login.
     - `Email`: User’s email address.
     - `Password`: User's hashed password for authentication.
     - `Phone_Number`: The phone number of the user.
   
2. **Role**:
   - The `Role` table defines the different roles available in the system, such as Student, Teacher, and Moderator.
   - **Fields**:
     - `ID`: The unique identifier for each role.
     - `RoleName`: The name of the role (e.g., Student, Teacher, Moderator).

3. **User Roles**:
   - The `User Roles` table connects each user to their respective roles, allowing for role-based access control.
   - **Fields**:
     - `UserID`: Foreign key referencing the `User` table.
     - `RoleID`: Foreign key referencing the `Role` table.
   
4. **App User**:
   - This table seems to be a general category for different types of users in the system.
   - **Fields**:
     - `Name`: The name of the application user.
   
5. **Moderator**:
   - The `Moderator` is a specialized user role responsible for overseeing content and platform usage.
   - This entity extends from the `User` entity via role mapping.

6. **Student**:
   - The `Student` table contains additional attributes specific to students.
   - **Fields**:
     - `InstituteName`: The name of the educational institute the student belongs to.
     - `InstituteID`: The unique identifier for the institute.

7. **Teacher**:
   - The `Teacher` table represents users who are teachers.
   - Teachers can answer students' questions and help clarify study topics.
   - Like the `Student` entity, the `Teacher` entity extends from the `User` table.

8. **Question**:
   - The `Question` table stores questions posted by students.
   - **Fields**:
     - `ID`: Unique identifier for each question.
     - `Content`: The text of the question.
     - `IsAnswered`: Boolean flag indicating whether the question has been answered.
     - `UserID`: Foreign key referencing the `User` who posted the question (likely a student).

9. **Answer**:
   - The `Answer` table stores answers provided by teachers.
   - **Fields**:
     - `ID`: Unique identifier for each answer.
     - `QuestionID`: Foreign key referencing the `Question` table.
     - `Content`: The text of the answer.
     - `UserID`: Foreign key referencing the `User` who answered the question (likely a teacher).

### Database Schema Diagram

Below is the ER (Entity Relationship) diagram that explains the structure of the database.

![Database Schema Diagram]([path-to-schema-image](https://github.com/user-attachments/assets/18d577b6-61f1-4abe-9508-18d0b61a483d)

The database schema consists of several entities with the following relationships:
- **User and Role**: The `User Roles` table connects users with their roles. A user can have multiple roles (e.g., a person can be both a teacher and a moderator).
- **Questions and Answers**: Students post questions in the `Question` table, and teachers provide answers, stored in the `Answer` table. Each answer is linked to a question via the `QuestionID`.
- **App Users**: Both students and teachers are derived from a common `App User` class, meaning they share certain common properties but are differentiated by role-specific attributes.


