# Husky.Net Setup for .NET Project

This project uses [Husky.Net](https://alirezanet.github.io/Husky.Net/guide/getting-started.html#installation) to enforce code quality checks before commits and pushes.

## Setup

### 1. **Install .NET SDK**
Ensure you have the .NET SDK installed:
```bash
dotnet --version
```

### 2. **Install Husky.Net (local recommended)**
```bash
cd <Your project root directory>
dotnet new tool-manifest # if you don't have one
dotnet tool install Husky
```

Or install globally:
```bash
dotnet tool install --global Husky
```

### 3. **Initialize Husky for your project**
```bash
dotnet husky install
```

## Add Git Hooks

### Add a Pre-commit Hook
```bash
dotnet husky add pre-commit -c "dotnet format && dotnet build"
git add .husky/pre-commit
```

### Add a Commit-msg Hook
```bash
dotnet husky add commit-msg -c "<your commit message validation script>"
git add .husky/commit-msg
```

### Add a Pre-push Hook
```bash
dotnet husky add pre-push -c "dotnet build && dotnet test"
git add .husky/pre-push
```

## Skipping Hooks (Emergency)
If you need to skip hooks in an emergency:
```bash
git commit -m "your message" --no-verify
git push --no-verify
```
⚠️ **Warning**: Only use `--no-verify` in emergencies. It bypasses important quality checks.

## Troubleshooting
- Ensure Husky.Net is installed: `dotnet tool list` or `dotnet tool list --global`
- Ensure hooks are executable: `chmod +x .husky/*`
- If .NET commands are not found, ensure .NET SDK is in your PATH.

## Reference
- [Husky.Net Official Guide](https://alirezanet.github.io/Husky.Net/guide/getting-started.html#installation) 