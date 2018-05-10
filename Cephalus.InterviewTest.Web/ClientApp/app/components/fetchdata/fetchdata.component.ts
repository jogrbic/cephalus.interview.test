import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
	templateUrl: './fetchdata.component.html',
	styleUrls: ['./fetchdata.component.css']
})
export class FetchDataComponent {
	public invoices: InvoiceModel[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		http.get(baseUrl + 'api/Invoice/GetInvoices').subscribe(result => {
			this.invoices = result.json() as InvoiceModel[];
        }, error => console.error(error));
    }
}

interface InvoiceModel {
	id: number,
	accountId: number,
	taxPointDate: Date,
	reference: string
	totalNet: number,
	totalVat: number,
	totalGross: number,
	addres: string,
	name: string
}
