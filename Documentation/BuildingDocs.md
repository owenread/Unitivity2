<!-- Basic Firestore document model  -->

projects/{projectId}               (Document)
  ├── id: string (UUID/GUID)
  ├── title: string
  ├── description: string
  ├── ownerId: string
  ├── isPublic: boolean
  ├── createdAtUtc: Timestamp
  ├── updatedAtUtc: Timestamp
  └── memberIds: array[string]     <-- Denormalized array for $arrayContains queries

<!-- Current Vertical Slice Layout -->

src/
├── Unitivity.Api/
│   ├── Common/
│   │   ├── Filters/ExceptionFilter.cs
│   │   └── Http/EnvelopeResult.cs      # { "data": ... } wrapper
│   └── Projects/
│       ├── Create/
│       │   ├── CreateProjectEndpointV1.cs
│       │   ├── CreateProjectRequest.cs
│       │   └── CreateProjectResponse.cs
│       └── Get/
│           ├── GetProjectEndpointV1.cs
│           └── GetProjectResponse.cs
├── Unitivity.Domain/
│   └── Projects/
│       ├── Create/
│       │   ├── CreateProjectCommand.cs
│       │   ├── CreateProjectCommandHandler.cs
│       │   └── IProjectCreator.cs      # Pure C# interface
│       ├── Get/
│       │   ├── GetProjectQuery.cs
│       │   ├── GetProjectQueryHandler.cs
│       │   └── IProjectReader.cs       # Pure C# interface
│       └── Shared/
│           └── Project.cs              # Pure POCO domain entity (zero SDK attributes)
├── Unitivity.Infrastructure/
│   ├── Configuration/
│   │   └── FirestoreOptions.cs
│   └── Projects/
│       ├── Common/
│       │   ├── ProjectDocument.cs      # Decorated with [FirestoreData] & [FirestoreProperty]
│       │   └── ProjectDocumentMapper.cs
│       ├── Create/
│       │   └── FirestoreProjectCreator.cs : IProjectCreator
│       └── Get/
│           └── FirestoreProjectReader.cs : IProjectReader
└── tests/
    └── Unitivity.Domain.Tests/
        └── Projects/Create/CreateProjectCommandHandlerTest.cs