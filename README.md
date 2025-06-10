# ADO.NET Task – Course Management System

A Windows Forms app built using ADO.NET to manage users, courses, and profiles. It demonstrates connected-mode database operations and a simple UI for interacting with SQL Server.

##  Features

###  Authentication
- Login with username and password.
- Track info loaded upon login.

###  Course Management
- View all available courses.
- Add new courses (name, description, duration, track).
- Edit and delete existing courses.

###  User Profile
- View personal profile info.
- Update selected fields (name, email, phone, image).

### 📑 User-Course Relationship
- `UserCourses` table tracks:
  - `UserID`, `CourseID`
  - `Status` (e.g., Enrolled, Completed)
  - `UserCourseID` (primary key)

> Note: This table exists in the schema, but isn’t directly handled in the current UI.

### 🔁 Logout
- Button to safely return to login screen.

##  Architecture

- **PL (Presentation Layer):**
  - WinForms UI: login screen, dashboard, course list, add/edit form, profile page.

- **BL (Business Logic Layer):**
  - Handles validation, profile/course logic, and data flow between UI and DAL.

- **DAL (Data Access Layer):**
  - Executes SQL commands and queries using ADO.NET.
  - Reusable methods for select and DML operations.

##  Technologies Used

- C# with .NET WinForms
- SQL Server
- ADO.NET (Connected Mode)
- Data binding via `DataTable`, `SqlDataAdapter`

##  Database Schema

- `Users(UserID, UserName, UserPass, TrackName)`
- `UserProfiles(UserID, FullName, Email, Phone, ProfileImage)`
- `Courses(CourseID, CourseName, Description, Duration, TrackName)`
- `UserCourses(UserCourseID, UserID, CourseID, Status)`


##  Notes

- Passwords are stored in plain text (demo purpose).
- SQL injection is prevented using parameters.
- Profile updates are handled selectively (null fields are skipped).
- No Entity Framework – pure ADO.NET usage.

---

