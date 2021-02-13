import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsComponentRef } from 'ngx-bootstrap/component-loader';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cidade } from '../models/Cidade';

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
  public cidades = [
    { id: '1', nome: 'Arapongas', estado: 'PR' },
    { id: '2', nome: 'Apucarana', estado: 'PR' },
    { id: '3', nome: 'Londrina', estado: 'PR' },
    { id: '4', nome: 'Maringá', estado: 'PR' },
    { id: '5', nome: 'São Paulo', estado: 'SP' },
  ]
  createForm() {
    this.cidadeForm = this.fb.group({
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
  }
  submit() {
    console.log(this.cidadeForm.value)
  }
  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.createForm();
  }

  ngOnInit(): void {
  }

}
