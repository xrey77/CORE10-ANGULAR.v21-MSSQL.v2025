import { Component, inject, OnInit } from '@angular/core';
import { Productservice } from '../services/productservice';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-saleschart',
  imports: [],
  templateUrl: './saleschart.html',
  styleUrl: './saleschart.scss',
})

export class Saleschart implements OnInit {
  private productsService = inject(Productservice);
  private sanitizer = inject(DomSanitizer);

  chartUrl: SafeResourceUrl | null = null;
  private currentBlobUrl: string | null = null;

  ngOnInit() {
    this.onViewReport();
  }

  onViewReport() {
    this.productsService.showSalesGraph().subscribe({
      next: (blob: Blob) => {
        if (this.currentBlobUrl) {
          URL.revokeObjectURL(this.currentBlobUrl);
        }

        this.currentBlobUrl = URL.createObjectURL(blob);
        this.chartUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.currentBlobUrl);
      },
      error: (err: any) => console.error('Error downloading PDF:', err)
    });
  }
}

