import { Injectable, EventEmitter } from '@angular/core';
import { Message } from '../Models/Message';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();

  // sender unique id 
  uniqueID: string = localStorage.getItem('conectionId');

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  baseUrl = "https://localhost:44326/";

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();      
    this.startConnection();
    
  }

   sendMessage(message: Message) {     
     this._hubConnection.invoke('NewMessage', message);  
  }  
  
  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(this.baseUrl+ 'Hubs/notifacationHub')
      .build();
   
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
        this.getConnectionId();
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () { this.startConnection(); }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('MessageReceived', (data: any) => {     
       if(this.uniqueID == data.toUserId){
        this.messageReceived.emit(data);
       }      
    });
  }

  getConnectionId(){
    // this._hubConnection.invoke('getConnectionId')
    // .then(function (connectionId) {
    //   console.log(connectionId)
    //     localStorage.setItem('conectionId', connectionId);
    //     // Send the connectionId to controller
    // }).catch(err => console.error(err.toString()));
  }

}
