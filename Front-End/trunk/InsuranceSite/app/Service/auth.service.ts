import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Global } from '../Shared/global'
import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
	constructor(private http: Http) { }

	login(username: string) {
		let headers = new Headers({ 'Content-Type': 'application/json' });
		let options = new RequestOptions({ headers: headers });

		return this.http.post('/api/auth', JSON.stringify({ username: username }), options)
			.map((response: Response) => {
				let user = response.json();
				if (user && user.id) {
					localStorage.setItem('currentUser', JSON.stringify(user));
				}
			});
	}

	logout() {
		localStorage.removeItem('currentUser');
	}
}