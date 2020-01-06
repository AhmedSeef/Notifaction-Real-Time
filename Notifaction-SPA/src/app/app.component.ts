import { Message } from './Models/Message';
import { Component, NgZone, OnDestroy } from '@angular/core';
import { NotificationsService } from './Services/NotificationsService';
import { Subscription } from 'rxjs';
import { SignalRServiceService } from './Services/SignalRService.service';
import { Mess } from './Models/mess';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy  {
   private signalRSubscription: Subscription; 
   public content: Mess={
  val1:"",
  val2:"",
  val3:"",
  val4:""
};
 
  txtMessage: string = '';
  toId:string = '';
  uniqueID: string = localStorage.getItem('conectionId');
  messages = new Array<Message>();
  message = new Message();
  constructor(
    private chatService: NotificationsService,
    private _ngZone: NgZone,
    private signalrService: SignalRServiceService
  ){
    this.subscribeToEvents();
    this.signalRSubscription = this.signalrService.getMessage().subscribe(
      (message) => {
        this.content = message;
    });
  }

  sendMessage(): void {
    if (this.txtMessage) {
      this.message = new Message();
      this.message.clientuniqueid = this.uniqueID;
      this.message.type = "sent";
      this.message.message = this.txtMessage;
      this.message.date = new Date();
      this.message.toUserId = this.toId;
      this.messages.push(this.message);
      this.chatService.sendMessage(this.message);
      this.txtMessage = '';
    }
  }

  private subscribeToEvents(): void {

    this.chatService.messageReceived.subscribe((message: Message) => {
      this._ngZone.run(() => {
        if (message.clientuniqueid !== this.uniqueID) {
          message.type = "received";
          this.messages.push(message);
        }
      });
    });
  }

  ngOnDestroy(): void {
    this.signalrService.disconnect();
    this.signalRSubscription.unsubscribe();
  }
}
