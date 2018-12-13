import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../../service/product.service';
import { AlertService } from '../../shared/services/alert.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateproductComponent implements OnInit {

  errorMsg: string;
  form: FormGroup;
  custId: any;
  items: any;
  errMsg: string;

  constructor(private builder: FormBuilder,
    private router: Router,
    private productSV: ProductService,
    private activateRouter: ActivatedRoute,
    private alertSV: AlertService) {
    this.initialCreateFormData();
    
  }
  ngOnInit() {
  }

  private initialCreateFormData() {
    this.form = this.builder.group({

      custId:['', [Validators.required]],
      name:['', [Validators.required]],
      lastname:['', [Validators.required]],
      custType:'' ,
     
    });
  }
 
  
  onSubmit() {

    console.log(this.form.value);
    const patt = /^[a-z,A-Z,ก-ฮ]{2,3000}$/;
    
    if (this.form.invalid) {
      console.log('ข้อมูลไม่ครบ');
      alert('ข้อมูลไม่ครบ');
    } else if (patt.test(this.form.get('name').value) === false) {
      console.log('name ผิดพลาด');
      alert('name ผิดพลาด');
    } else if (patt.test(this.form.get('lastname').value) === false) {
      console.log('lastname ผิดพลาด');
      alert('lastname ผิดพลาด');
    } else {
      this.productSV
        .createProduct(JSON.stringify(this.form.value))
        .then(res => {
          this.alertSV.notify('เพิ่มข้อมูลเรียบร้อยแล้ว', 'success')
          this.router.navigate(['/', 'home']);
        })
        .catch(err => this.errorMsg = err);

    }
  }
}