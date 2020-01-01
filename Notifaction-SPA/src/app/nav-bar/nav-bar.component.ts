import { Component, OnInit, NgZone, Input } from '@angular/core';
import { NotificationsService } from '../Services/NotificationsService';
import { Message } from '../Models/Message';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
name:string = 'intiall'

@Input() message :Message; 
counter:number = 0;
  constructor(
    private chatService: NotificationsService,
    private _ngZone: NgZone
  ){
    console.log(this.name)
  }

  ngOnInit() {
    console.log(name)
  }

 
}
