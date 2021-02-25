import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsComponentRef } from 'ngx-bootstrap/component-loader';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cidade } from '../models/Cidade';
import { CidadesService } from '../services/Cidades.service';

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})
export class CidadeComponent implements OnInit {
  titleCidade = 'Cidade'
  public selectedCidade: Cidade;
  public cidadeForm: FormGroup;
  public modalRef: BsModalRef;
  public cidades: Cidade[];
  createForm() {
    this.cidadeForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      estado: ['', Validators.required],
    });

  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  selectCidade(cidade: Cidade) {
    this.selectedCidade = cidade;
    this.cidadeForm.patchValue(cidade);
  }
  back() {
    this.selectedCidade = null;
    this.loadCidade();
  }
  saveCidade(cidade: Cidade){
    this.cidadesService.edit(cidade).subscribe(
      (retorno:Cidade)=> {
        console.log(retorno);
      },
      (error:any)=> {
        console.log(error);
      }
      );
  }
  loadCidade() {
    this.cidadesService.getAll().subscribe(
      (cidade: Cidade[]) => {
        this.cidades = cidade;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  submit() {
    console.log(this.cidadeForm.value);
    this.saveCidade(this.cidadeForm.value);
    
  }
  deleteCidade(id: number) {
    this.cidadesService.delete(id).subscribe(
      (modal: any) => {
        this.loadCidade();
        console.log(modal);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  constructor(private fb: FormBuilder, private modalService: BsModalService, private cidadesService: CidadesService) {
    this.createForm();
  }
  ngOnInit(): void {
    this.loadCidade();
  }

}
