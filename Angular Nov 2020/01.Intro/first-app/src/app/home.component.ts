import { Component } from '@angular/core';

@Component ({
    selector: 'home',
    template: `
    <div>
        <h1>Hello from the Home Component</h1>
    </div>`,
    styles: [`div {
        padding: 10px 30px 10px 30px;
        padding-right: 20px;
        margin-bottom: 20px;
        border-radius: 5px;
        box-shadow: 0 2px 5px 1px rgba(0, 0, 0, 0.4);
    } `]
})

export class HomeComponent {
    
}