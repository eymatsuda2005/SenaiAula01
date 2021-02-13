import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Medico } from '../models/Medico';

@Component({
  selector: 'app-medico',
  templateUrl: './medico.component.html',
  styleUrls: ['./medico.component.css']
})
export class MedicoComponent implements OnInit {
  titleMedico = 'Médicos'

  public selectedMedico: Medico;
  public medicoForm: FormGroup;
  public modalRef: BsModalRef;

  public medicos = [
    { id: '1', nome: 'João', especialidade: 'Cardiologista', crm: '432590', telefone: '99999-0000' },
    { id: '2', nome: 'Clovis', especialidade: 'Clínico Geral', crm: '158900', telefone: '90000-8888' },
    { id: '3', nome: 'Luiz', especialidade: 'Psicólogo', crm: '676626', telefone: '77777-0000' },
    { id: '4', nome: 'Cleyton', especialidade: 'Pneumologista', crm: '787652', telefone: '88888-9898' },
    { id: '5', nome: 'Chico', especialidade: 'Otorrinolaringologista', crm: '879002', telefone: '99000-8890' }
  ]


  createForm() {
    this.medicoForm = this.fb.group({
      nome: ['', Validators.required],
      especialidade: ['', Validators.required],
      crm: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  selectMedico(medico: Medico) {
    this.selectedMedico = medico;
    this.medicoForm.patchValue(medico);
  }
  back() {
    this.selectedMedico = null;
  }
  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.createForm();
  }
  submit() {
    console.log(this.medicoForm.value)
  }
  ngOnInit(): void {
  }

}
