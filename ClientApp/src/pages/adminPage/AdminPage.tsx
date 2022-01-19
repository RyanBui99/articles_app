import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Container from '@material-ui/core/Container';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import ButtonGroup from '@material-ui/core/ButtonGroup';
import NavbarComponent from '../../components/NavbarComponent';
import CreateUserModal from '../../components/modals/CreateUserModal';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getUsers } from '../../store/actionCreators/userCreator';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  container: {
    marginTop: theme.spacing(4),
  },
  paper: {
    padding: theme.spacing(3),
    color: theme.palette.text.secondary,
  },
}));

export default function admin() {
  const [open, setOpen] = React.useState(false);
  const dispatch = useDispatch()
  const { users } = useTypedSelector((state) => state.users)
  const classes = useStyles();

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  React.useEffect(() => {
    const fetchUsers = async () => {
      await dispatch(getUsers())
    }
    fetchUsers()
  }, [dispatch])

  return (
    <>
      <NavbarComponent />
      <div className={classes.root}>
        <Container className={classes.container} maxWidth='md'>
          <Paper className={classes.paper}>
            <Box display='flex'>
              <Box flexGrow={2}>
                <Typography
                  component='h2'
                  variant='h6'
                  color='primary'
                  gutterBottom
                >
                  USERS
                </Typography>
              </Box>
              <Box>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={handleClickOpen}
                >
                  CREATE
                </Button>
                <CreateUserModal handleclose={handleClose} open={open} />
              </Box>
            </Box>
            <TableContainer component={Paper}>
              <Table aria-label='simple table'>
                <TableHead>
                  <TableRow>
                    <TableCell align='center'>ID</TableCell>
                    <TableCell align='left'>Username</TableCell>
                    <TableCell align='left'>Role</TableCell>
                    <TableCell align='center'>Action</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {users.map((user, key) => (
                    <TableRow key={key}>
                      <TableCell align='center'>{user.id}</TableCell>
                      <TableCell align='left'>{user.username}</TableCell>
                      <TableCell align='left'>{user.role}</TableCell>
                      <TableCell align='center'>
                        <ButtonGroup
                          color='primary'
                          aria-label='outlined primary button group'
                        >
                          <Button>Edit</Button>
                          <Button color='secondary'>Delete</Button>
                        </ButtonGroup>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Paper>
        </Container>
      </div>
    </>
  );
}
