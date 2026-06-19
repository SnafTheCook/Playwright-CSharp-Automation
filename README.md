# Enterprise E2E Automation Framework

This repository demonstrates a modern, production-ready End-to-End testing architecture using **C# .NET 10, Playwright, and xUnit v3**. The target application is [SauceDemo](https://www.saucedemo.com/).

## Architectural Highlights
- **Out-of-Process Execution:** Fully embraces the xUnit v3 architecture (Standalone Executable) for maximum isolation and stability, bypassing legacy test adapters.
- **Strict Page Object Model (POM):** Built using Composition and SOLID principles. Locators are encapsulated (`private readonly`) to prevent logic bleed.
- **Web-First Assertions:** Zero usage of `Thread.Sleep()`. The framework relies entirely on asynchronous state polling and active waiting.
- **Accessibility & Semantic Testing:** Utilizes `ToMatchAriaSnapshotAsync` and `GetByRole()` to validate the DOM based on W3C accessibility trees rather than fragile CSS/XPath selectors.
- **Data-Driven Scalability:** Implements xUnit `[Theory]` attributes for multi-dataset coverage with zero code duplication.
- **Cloud-Native CI/CD:** Fully automated via GitHub Actions with dual-layer caching (NuGet & Playwright binaries) for highly optimized execution times on Ubuntu containers.

## How to Run Locally

1. Clone the repository.
2. Build the project to restore tools:
   ```bash
   dotnet build
   ```
3. Run the xUnit v3 suite natively:
   ```bash
   dotnet run --project SauceDemo.UITests/SauceDemo.UITests.csproj
   ```