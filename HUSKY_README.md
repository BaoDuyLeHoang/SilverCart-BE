# Husky Setup for .NET Project

This project uses Husky to enforce code quality checks before commits and pushes.

## Setup

1. **Install Node.js** (if not already installed)
   ```bash
   # Download from https://nodejs.org/
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Initialize Husky**
   ```bash
   npm run prepare
   ```

## Available Hooks

### Pre-commit Hook
Runs before each commit:
- ✅ Formats code automatically using `dotnet format`
- ✅ Builds the project to catch compilation errors

### Commit-msg Hook
Validates commit message format:
- ✅ Ensures conventional commits format
- ✅ Example: `feat(auth): add login functionality`

### Pre-push Hook
Runs before pushing to remote:
- ✅ Builds the project
- ✅ Runs all tests
- ✅ Checks code formatting

## Commit Message Format

Follow the conventional commits format:
```
<type>(<scope>): <description>

[optional body]

[optional footer(s)]
```

### Types:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

### Examples:
```bash
git commit -m "feat(auth): add JWT authentication"
git commit -m "fix(products): resolve foreign key constraint issue"
git commit -m "docs(readme): update installation instructions"
git commit -m "test(api): add product controller tests"
```

## Available NPM Scripts

```bash
npm run build          # Build the .NET project
npm run test           # Run all tests
npm run test:coverage  # Run tests with coverage
npm run clean          # Clean build artifacts
npm run format         # Format code
npm run lint           # Check code formatting
npm run pre-push       # Run all pre-push checks
```

## Skipping Hooks (Emergency)

If you need to skip hooks in an emergency:

```bash
# Skip pre-commit hook
git commit -m "your message" --no-verify

# Skip pre-push hook
git push --no-verify
```

⚠️ **Warning**: Only use `--no-verify` in emergencies. It bypasses important quality checks.

## Troubleshooting

### Hook not running
1. Ensure Husky is installed: `npm install`
2. Ensure hooks are executable: `chmod +x .husky/*`
3. Check if hooks are in `.git/hooks/`

### Permission denied
```bash
chmod +x .husky/pre-commit
chmod +x .husky/commit-msg
chmod +x .husky/pre-push
```

### .NET commands not found
Ensure .NET SDK is installed and in your PATH:
```bash
dotnet --version
```

## Configuration Files

- `package.json`: NPM scripts and Husky configuration
- `.husky/pre-commit`: Pre-commit hook script
- `.husky/commit-msg`: Commit message validation
- `.husky/pre-push`: Pre-push quality checks 