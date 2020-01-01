import { Message } from './Models/Message';
import { Component, NgZone } from '@angular/core';
import { NotificationsService } from './Services/NotificationsService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  txtMessage: string = '';
  toId:string = '';
  uniqueID: string = localStorage.getItem('conectionId');
  messages = new Array<Message>();
  message = new Message();
  constructor(
    private chatService: NotificationsService,
    private _ngZone: NgZone
  ){
    this.subscribeToEvents();
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
}
