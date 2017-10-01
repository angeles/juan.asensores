import { PipeTransform, Pipe } from '@angular/core';
import { IPolicy } from '../Models/policy';

@Pipe({
	name: 'policyFilter'
})

export class PolicyFilterPipe implements PipeTransform {

	transform(value: IPolicy[], filter: string): IPolicy[] {
		filter = filter ? filter.toLocaleLowerCase() : null;
		return filter ? value.filter((app: IPolicy) =>
			app.email != null && app.email.toLocaleLowerCase().indexOf(filter) != -1
		) : value;

	}
}