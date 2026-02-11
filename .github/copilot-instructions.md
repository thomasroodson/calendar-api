# Copilot Instructions

## General Guidelines
- First general instruction
- Second general instruction

## Code Style
- Use specific formatting rules
- Follow naming conventions

## Project-Specific Rules
- Prefer reducing validation duplication by creating reusable helpers/extensions (e.g., MongoObjectId rule, ValidateOrThrowAsync extension that throws ErrorOnValidationException).
- The project uses FluentValidation and has use cases that repeat validation. Remember to apply these recommendations when implementing validation logic.