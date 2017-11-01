import { Component, OnDestroy } from "@angular/core"
import { Subscription } from 'rxjs/Subscription';
import { MessageService } from './Service/message.service';

@Component({
	selector: "user-app",
	templateUrl: 'app/app.component.html'
})

export class AppComponent implements OnDestroy {
	loggedInUser: string = null;
	subscription: Subscription;

	constructor(private messageService: MessageService) {
		// subscribe to home component messages
		this.subscription = this.messageService.getMessage().subscribe(message => { this.loggedInUser = message.text; });
		if (localStorage != null && localStorage.getItem('currentUser') != null)
			this.loggedInUser = JSON.parse(localStorage.getItem('currentUser')).name;
	}

	ngOnDestroy() {
		// unsubscribe to ensure no memory leaks
		this.subscription.unsubscribe();
	}
}