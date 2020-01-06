import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Mess } from '../Models/mess';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRServiceService {
  baseUrl = "https://localhost:44326/";
  private message$: Subject<Mess>;
  private connection: signalR.HubConnection;

  constructor() {
    this.message$ = new Subject<Mess>();
    this.createconnection();
    this.connect();
  }

  private createconnection(){
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(this.baseUrl + "SignalR/notificationHub")
      .build();
  }
  private connect() {
    this.connection.start().catch(err => console.log(err));
  }

  getMessage(): Observable<Mess> {
    this.connection.on('SendMessage', (message) => {
      this.message$.next(message);
    });
    return this.message$.asObservable();
  }
  disconnect() {
    this.connection.stop();
  }

}
