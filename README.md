# MiniTube

A **WPF desktop video platform** in C# — browse, search and play videos as a Viewer, or upload and manage
them as a Creator. Around 3,200 lines of C# across 11 XAML views, backed by Entity Framework over SQL
Server.

Built as a university project (Enterprise Application Development, UET Lahore).

---

## Stack

| | |
|---|---|
| UI | WPF, XAML |
| Language | C# (.NET) |
| Data | Entity Framework, SQL Server |

## What it does

**Both roles**
- Register, log in, reset a forgotten password

**Viewer**
- Randomised video feed on the main screen
- Keyword search across titles
- Dedicated playback screen with transport controls
- Like and comment on a video

**Creator**
- Upload videos through a guided flow
- Studio view listing everything you have uploaded, with edit and delete
- Insights view aggregating likes, comments and engagement per video

---

## Layout

```
App.xaml(.cs)          application lifecycle and shared resources
Context/               MiniTubeContext — EF Core context
Models/                User, Video, Comment, Like
ModelsEAD/             database-first scaffold kept alongside the hand-written models
View/                  11 XAML views + code-behind
Images/                icons and backgrounds
```

The 11 views: `FirstPageControl`, `LoginViewIn`, `RegisterationView`, `RegisterationViewIn`, `ResetView`,
`UserView`, `PlayerView`, `PlayerControl`, `StudioView`, `StudioControl`, `UploadingView`, `InsightView`.

Both a hand-written model set (`Models/`) and a scaffolded one (`ModelsEAD/`) are in the repository —
the course covered code-first and database-first, and both are preserved rather than one being deleted.

---

## Running it

Needs the .NET SDK, Visual Studio (or `dotnet` with a Windows target) and SQL Server.

```bash
# point the connection string in MiniTubeContext at your SQL Server instance
dotnet restore
dotnet run --project MiniTube
```

`Documentation.docx` in the project folder has the original write-up, including the schema diagram.

---

## Known limitations

This is coursework and reads like it in places:

- **Logic lives in code-behind**, not in view models. It is not MVVM, which is the pattern a WPF
  application this size should use — that is the single biggest thing I would change.
- **Passwords are handled by the application directly** rather than through a vetted hashing library.
- **Videos are stored on the local file system**, so the app is single-machine.
- **No tests.**
- **Windows only**, being WPF.

## Built by

Malik Shujaat Ali — [github.com/MalikShujaatAli](https://github.com/MalikShujaatAli) ·
[linkedin.com/in/malik-shujaat-ali](https://www.linkedin.com/in/malik-shujaat-ali)
