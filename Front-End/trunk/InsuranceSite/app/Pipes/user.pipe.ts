import { PipeTransform, Pipe } from '@angular/core';
import { IUser } from '../Models/user';

@Pipe({
	name: 'userFilter'
})

export class UserFilterPipe implements PipeTransform {

	transform(value: IUser[], filter: string): IUser[] {
		filter = filter ? filter.toLocaleLowerCase() : null;
		return filter ? value.filter((app: IUser) =>
			app.name != null && app.name.toLocaleLowerCase().indexOf(filter) != -1
			|| app.email != null && app.email.toLocaleLowerCase().indexOf(filter) != -1
			|| app.role != null && app.role.toLocaleLowerCase().indexOf(filter) != -1

		) : value;

	}
}