import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
declare var $: any; 


@Component({
  selector: 'app-Test',
  templateUrl: './Test.component.html',
  styleUrls: ['./Test.component.css']
})
export class TestComponent implements OnInit {
  commonData: CommonData = { Message: "" };
 
  constructor(private http:HttpClient) { 
    this.getCommonData();
  }

  getCommonData() {
    this.http.get(`https://localhost:44326/api/test`).subscribe(
      (data:CommonData)=>{this.commonData = data;console.log(this.commonData)}
      );
  }

  setCommonData() {
    
    this.http.post('https://localhost:44326/api/test',this.commonData).subscribe()
}

  ngOnInit() {
  }

}

export class CommonData {
  Message: string;
}
