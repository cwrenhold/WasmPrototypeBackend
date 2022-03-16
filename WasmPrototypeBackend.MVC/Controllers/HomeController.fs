namespace WasmPrototypeBackend.MVC.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

open WasmPrototypeBackend.MVC.Models

type HomeController (logger : ILogger<HomeController>) =
    inherit Controller()

    member this.Index () =
        this.View()

    member this.Privacy () =
        this.View()

    member this.People () =
        let random = new Random(0)
        let totalSubjs = 10

        let buildCharacteristic characteristicId =
            let rand = random.Next(1, 20)
            { Id = characteristicId; Name = characteristicId.ToString(); ValueId = rand; Value = rand.ToString() }

        let buildMark personId markId =
            match random.NextDouble() with
            | a when a < 0.1 -> None
            | _ -> 
                let value = random.Next(1, 10)
                Some { Id = markId; PersonId = personId; SubjectId = markId; MarkType = MarkType.Grade; MarkText = value.ToString(); MarkValue = float value }

        let data =
            [1..50]
            |> Seq.map (fun personId -> 
                { 
                    Id = personId;
                    Name = personId.ToString();
                    Characteristics = 
                        [1..5]
                        |> List.map buildCharacteristic 
                    Subjects = 
                        [1..totalSubjs]
                        |> List.map (fun s -> { Id = s; Name = s.ToString() })
                    Marks = 
                        [1..totalSubjs]
                        |> List.map (buildMark personId)
                })
        this.Json data

    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error () =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })
