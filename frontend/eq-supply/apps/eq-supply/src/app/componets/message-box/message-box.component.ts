import { Component, OnInit, Injectable, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.css']
})
export class MessageBoxComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<MessageBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IDialogData) { }

  ngOnInit() {
  }

  visible(value: number) {
    return (this.data.buttons & value) === value;
  }

  onButton(value: MessageBoxButtons) {
    this.dialogRef.close(value);
  }

}

export enum MessageBoxButtons {
  Ok = 1,
  Cancel = 2,
  Yes = 4,
  No = 8,
  YesNoCancel = 14
}

export interface IDialogData {
  caption: string;
  text: string;
  buttons: MessageBoxButtons;
}

/**Сервис диалогового окна */
@Injectable()
export class MessageBox {
  constructor(private dialog: MatDialog) { }
  public show(
    caption: string | IDialogData,
    text?: string,
    buttons: MessageBoxButtons = MessageBoxButtons.Ok
  ) {
    if (typeof caption === 'string') {
      return this.dialog.open(MessageBoxComponent, {
        disableClose: true,
        data: {
          caption,
          text,
          buttons
        }
      });
    } else if (typeof caption.caption === 'string') {
      return this.dialog.open(MessageBoxComponent, {
        disableClose: true,
        data: caption
      });
    }
  }

  confirm(caption: string, confirmText: string) {
    const confirmDialog = this.show(caption, confirmText, MessageBoxButtons.Yes | MessageBoxButtons.No);
    return confirmDialog.afterClosed()
      .map((button: MessageBoxButtons) => {
        switch (button) {
          case MessageBoxButtons.Yes:
            return true;
          case MessageBoxButtons.No:
            throw new Error('No');
        }
      })
  }
}
