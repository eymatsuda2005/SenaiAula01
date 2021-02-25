import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Medico } from '../models/Medico';
import { MedicosService } from '../services/Medicos.service';

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

  public medicos: Medico[];

  createForm() {
    this.medicoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      especialidade: [''],
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
    this.loadMedico();
  }
  constructor(private fb: FormBuilder, private modalService: BsModalService, private medicoService: MedicosService) {
    this.createForm();
  }
  submit() {
    console.log(this.medicoForm.value)
    this.saveMedico(this.medicoForm.value);
  }
  saveMedico(medico: Medico) {
    this.medicoService.edit(medico).subscribe(
      (retorno: Medico) => {
        console.log(retorno);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  loadMedico() {
    this.medicoService.getAll().subscribe(
      (medicos: Medico[]) => {
        this.medicos = medicos;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  deleteMedico(id: number) {
    this.medicoService.delete(id).subscribe(
      (modal: any) => {
        this.loadMedico();
        console.log(modal);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  ngOnInit(): void {
    this.loadMedico();
  }

}
