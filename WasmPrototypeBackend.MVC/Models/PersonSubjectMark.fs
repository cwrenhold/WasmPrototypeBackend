namespace WasmPrototypeBackend.MVC.Models

type MarkType =
    | Grade = 1

type PersonSubjectMarkModel =
    {
        Id: int
        PersonId: int
        SubjectId: int
        MarkType: MarkType
        MarkText: string
        MarkValue: float
    }

