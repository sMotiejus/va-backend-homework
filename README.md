# Vinted Academy Backend Homework

## 📌 Project Overview
This is a backend application developed in **.NET 8**.

## 📂 Project Structure
```
📦 VintedAcademyBackendHomework  
├── 📂 VintedAcademyBackendHomework/   # Main application source code  
│   ├── 📂 Services/                   # Business logic services  
│   ├── 📂 Models/                     # Data models and entities  
│   ├── 📂 Rules/                      # Transaction rules  
│   ├── 📂 Utils/                      # Utility classes (Date, Money, etc.)  
│   └── Program.cs                     # Entry point of the application  
├── 📂 Tests/                          # Unit tests  
│   ├── FileReaderTests.cs             # Tests for FileReader  
│   ├── ProviderServiceTests.cs        # Tests for ProviderService  
│   ├── TransactionServiceTests.cs     # Tests for TransactionService  
│   └── MoqDataForTesting.cs           # Mock data setup  
├── .gitignore                         # Git ignore file  
├── VintedAcademyBackendHomework.sln   # Solution file  
└── README.md                          # Project documentation   
```

## 🚀 Getting Started

### 🔧 Needed framework
- **.NET 8 SDK** installed ([Download here](https://dotnet.microsoft.com/download/dotnet/8.0))  

### 💻 Setup & Build
```sh
git clone https://github.com/sMotiejus/va-backend-homework.git
cd va-backend-homework-master
dotnet restore  # Restore dependencies (For testring only, no external dependencies are used in the program itself)
dotnet build    # Build the project  
```

### 🧪 Running Tests
While being in Main folder (e.g., va-backend-homework):
```sh
dotnet test  # Run all tests  
```

### ▶ Running the Application
#### Relative input.txt path (Main folder)
- While in the main folder (e.g., va-backend-homework)
- input.txt or any .txt file should be in the same folder from which you call the function.
```sh
dotnet run --project .\VintedAcademyBackendHomework\VintedAcademyBackendHomework.csproj input.txt
```
#### Absolute input.txt path (Main folder)
- While in the main folder (e.g., va-backend-homework)
- Use the absolute path of the file.
```sh
dotnet run --project .\VintedAcademyBackendHomework\VintedAcademyBackendHomework.csproj C:/input.txt
```

#### Relative input.txt path (Inside VintedAcademyBackendHomework folder)
- While inside the VintedAcademyBackendHomework folder.
- input.txt or any .txt file should be in the same folder from which you call the function.
```sh
dotnet run input.txt
```
#### Absolute input.txt path (Inside VintedAcademyBackendHomework folder)
- While inside the VintedAcademyBackendHomework folder.
- Use the absolute path of the file.
```sh
dotnet run C:/input.txt
```
