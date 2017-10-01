export interface IPolicy {
	id: AAGUID,
	amountInsured: number,
	email: string,
	inceptionDate: Date,
	installmentPayment: boolean,
	clientId: AAGUID
}