# Synetec Assessment API

## Notes
- First of all, before starting refactoring we should (must) write Unit Tests to ensure that we won’t break the existing logic. (TDD)
- Next steps were splitting the project & logic but keeping in mind the acronyms: DRY, KISS, YAGNI, SOLID, BDUF, and SOC.
- Use Repository Pattern.
- Configure DB and DI.

### Specific Notes
We could use two different controllers & services for Employee and BonusPool but I think the project is so small and there is no need for this split.
(Changing endpoints too.)

In addition to, we could handle Errors differently using ErrorMiddleware or Newtonsoft.Json.

### Notes for reviewer
Projects had different target frameworks 3.1 and 5 when I forked.

Sdk: 5.0.205

If you have trouble running the project, feel free to email me to Dockerize it.
