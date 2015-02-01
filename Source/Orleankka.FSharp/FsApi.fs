﻿module Orleankka.FSharp

open System.Threading.Tasks

/// <summary>
/// Unidirectional send operator. 
/// Sends a message object directly to actor tracked by actorRef. 
/// </summary>
let inline (<!) (actorRef : ActorRef) (message : obj) : Task = actorRef.Tell(message)
        

module Async = 
   open System.Threading.Tasks
   
   let inline AwaitVoidTask (task : Task) = 
      let continuation (t : Task) : unit = 
         match t.IsFaulted with
         | true -> raise t.Exception
         | arg -> ()
      task.ContinueWith continuation |> Async.AwaitTask