namespace WasmPrototypeBackend.MVC.Models

type PersonCharacteristicModel =
    {
        Id: int;
        Name: string;
        ValueId: int;
        Value: string;
    }

type PersonModel =
    { 
        Id: int
        Name: string
        Characteristics: PersonCharacteristicModel list
        Subjects: SubjectModel list
        Marks: PersonSubjectMarkModel option list
    }

