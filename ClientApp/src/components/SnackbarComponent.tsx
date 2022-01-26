import { Snackbar } from '@material-ui/core';
import React from 'react';
import { Alert, AlertColor } from '@mui/material';

interface Prop {
  open: boolean,
  handleClose: () => void
  message: string,
  severity: AlertColor | undefined
}

export default function SnackbarComponent({open, handleClose, message, severity}: Prop) {
  return (
    <Snackbar
      style={{ marginTop: '5em' }}
      open={open}
      onClose={handleClose}
      anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
    >
      <Alert severity={severity}>{message}</Alert>
    </Snackbar>
  );
}
