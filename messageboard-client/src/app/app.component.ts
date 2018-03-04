import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { Message } from './message';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private hubConnection: HubConnection;
  public messages: Message[] = [];
  public errors = [];
  public message = new Message();

  public sendMessage(message: Message): void {
    this.hubConnection
      .invoke('send', message)
      .catch(err => this.errors.push(err));
  }

  public getMessages(skip: number, take: number) {
    this.hubConnection
        .invoke('get', skip, take)
        .catch(e => this.errors.push(e));
  }

  ngOnInit() {
    this.hubConnection = new HubConnection('http://localhost:5000/message');

    this.hubConnection
      .start()
      .then(() => this.getMessages(0, 10))
      .catch(e => this.errors.push(e));

      this.hubConnection.on('send', (data: Message) => {
        this.messages.push(data);
      });

      this.hubConnection.on('get', (data: Array<Message>) => {
        console.log(data);
        this.messages = data;
      });

    }
}
