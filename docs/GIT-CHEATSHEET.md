# Git Cheatsheet - Panduan Lengkap untuk CMD

## 📚 Daftar Isi
1. [Setup Awal](#setup-awal)
2. [Basic Commands](#basic-commands)
3. [Branching](#branching)
4. [Commit & Staging](#commit--staging)
5. [Remote & Push/Pull](#remote--pushpull)
6. [Menghapus File](#menghapus-file)
7. [Undo Changes](#undo-changes)
8. [History & Log](#history--log)
9. [Stashing](#stashing)
10. [Collaboration](#collaboration)

---

## 🚀 Setup Awal

### Konfigurasi Git (wajib pertama kali)
```bash
# Set nama Anda
git config --global user.name "Nama Anda"

# Set email Anda
git config --global user.email "email@example.com"

# Cek konfigurasi
git config --list
```

### Inisialisasi Repository
```bash
# Buat repository baru di folder saat ini
git init

# Clone repository dari GitHub
git clone https://github.com/username/repository.git
```

---

## 📝 Basic Commands

### Cek Status
```bash
# Cek status repository
git status

# Cek branch saat ini
git branch

# Cek semua branch (remote dan lokal)
git branch -a
```

### Melihat Perubahan
```bash
# Lihat perubahan yang belum di-staged
git diff

# Lihat perubahan yang sudah di-staged
git diff --staged

# Lihat perubahan antar branch
git diff branch1 branch2
```

---

## 🌳 Branching

### Membuat Branch
```bash
# Buat branch baru
git branch nama-branch

# Buat dan pindah ke branch baru
git checkout -b nama-branch

# Atau (Git versi baru):
git switch -c nama-branch
```

### Pindah Branch
```bash
# Pindah ke branch yang ada
git checkout nama-branch

# Atau (Git versi baru):
git switch nama-branch

# Kembali ke branch sebelumnya
git checkout -
```

### Menghapus Branch
```bash
# Hapus branch lokal (pastikan bukan branch aktif)
git branch -d nama-branch

# Force delete branch (jika belum merged)
git branch -D nama-branch

# Hapus branch remote
git push origin --delete nama-branch
```

### Rename Branch
```bash
# Rename branch saat ini
git branch -m nama-baru

# Rename branch tertentu
git branch -m nama-lama nama-baru
```

### Merge Branch
```bash
# Merge branch lain ke branch saat ini
git merge nama-branch- lain

# Merge dengan auto-commit message
git merge nama-branch-lain --no-ff
```

---

## 💾 Commit & Staging

### Menambah File ke Staging
```bash
# Tambah file tertentu
git add nama-file

# Tambah semua file
git add .

# Tambah semua file yang sudah tracked
git add -u

# Tambah file secara interaktif
git add -i
```

### Commit
```bash
# Commit dengan pesan
git commit -m "Pesan commit"

# Commit dan add sekaligus (hanya file yang sudah tracked)
git commit -am "Pesan commit"

# Commit dengan pesan panjang
git commit
# (akan membuka editor untuk tulis pesan)

# Amend commit terakhir (ubah pesan atau tambah file)
git commit --amend
```

### Melihat Commit
```bash
# Lihat commit history
git log

# Lihat commit history singkat
git log --oneline

# Lihat commit history dengan grafik
git log --graph --oneline --all

# Lihat commit terakhir
git log -1

# Lihat perubahan di commit tertentu
git show commit-hash
```

---

## 🌐 Remote & Push/Pull

### Menambah Remote
```bash
# Tambah remote repository
git remote add origin https://github.com/username/repo.git

# Lihat remote
git remote -v

# Hapus remote
git remote remove origin

# Ubah URL remote
git remote set-url origin https://github.com/username/repo-baru.git
```

### Push ke GitHub
```bash
# Push branch saat ini ke remote
git push

# Push branch saat ini dan set upstream
git push -u origin nama-branch

# Push semua branch
git push --all

# Push dengan force (hati-hati!)
git push --force

# Push dengan force lease (lebih aman)
git push --force-with-lease
```

### Pull dari GitHub
```bash
# Pull dari remote
git pull

# Pull dengan rebase (history lebih bersih)
git pull --rebase

# Pull dari branch tertentu
git pull origin nama-branch

# Fetch tanpa merge
git fetch

# Fetch dari remote tertentu
git fetch origin
```

### Sync dengan Remote
```bash
# Update semua remote tracking
git remote update

# Prune branch yang sudah dihapus di remote
git remote prune origin
```

---

## 🗑️ Menghapus File

### Hapus dari Git dan Lokal
```bash
# Hapus file dari git dan folder lokal
git rm nama-file

# Hapus folder dari git dan lokal
git rm -r nama-folder

# Hapus dengan force
git rm -f nama-file
```

### Hapus Hanya dari Git (Keep di Lokal)
```bash
# Hapus dari git tapi file tetap ada di komputer
git rm --cached nama-file

# Hapus folder dari git tapi tetap ada di komputer
git rm -r --cached nama-folder
```

### Setelah Hapus
```bash
# Commit perubahan
git add .
git commit -m "Hapus file"
git push
```

### Contoh: Hapus file yang sudah di-commit tapi tidak mau di-push
```bash
# Reset ke commit sebelumnya (hapus commit terakhir)
git reset --soft HEAD~1

# Atau hard reset (hapus semua perubahan)
git reset --hard HEAD~1
```

---

## ↩️ Undo Changes

### Undo di Working Directory
```bash
# Undo perubahan di file tertentu
git checkout nama-file

# Atau (Git versi baru):
git restore nama-file

# Undo semua perubahan
git checkout .

# Atau:
git restore .
```

### Undo di Staging Area
```bash
# Unstage file (kembali ke working directory)
git reset HEAD nama-file

# Atau:
git restore --staged nama-file

# Unstage semua file
git reset HEAD
```

### Undo Commit
```bash
# Reset ke commit sebelumnya (perubahan tetap di working directory)
git reset --soft HEAD~1

# Reset ke commit sebelumnya (hapus perubahan)
git reset --hard HEAD~1

# Reset ke commit tertentu
git reset --hard commit-hash

# Undo commit tapi buat commit baru (reverse)
git revert commit-hash
```

### Amend Commit Terakhir
```bash
# Ubah pesan commit terakhir
git commit --amend -m "Pesan baru"

# Tambah file yang lupa ke commit terakhir
git add nama-file
git commit --amend --no-edit
```

---

## 📜 History & Log

### Melihat History
```bash
# Lihat semua commit
git log

# Lihat commit singkat
git log --oneline

# Lihat commit dengan grafik
git log --graph --oneline --all

# Lihat commit dengan diff
git log -p

# Lihat commit file tertentu
git log nama-file

# Lihat commit by author
git log --author="Nama"
```

### Mencari di History
```bash
# Cari commit dengan pesan tertentu
git log --grep="pesan"

# Cari commit yang mengubah file tertentu
git log --follow nama-file

# Cari commit yang menghapus file
git log --diff-filter=D --summary
```

### Blame (Siapa yang mengubah baris ini?)
```bash
# Lihat siapa yang mengubah setiap baris
git blame nama-file

# Blame dengan range baris
git blame -L 10,20 nama-file
```

---

## 💼 Stashing

### Simpan Perubahan Sementara
```bash
# Stash perubahan saat ini
git stash

# Stash dengan pesan
git stash save "Pesan stash"

# Stash include untracked files
git stash -u

# Stash include ignored files
git stash -a
```

### Lihat dan Restore Stash
```bash
# Lihat semua stash
git stash list

# Apply stash terakhir (tanpa menghapus stash)
git stash apply

# Apply stash tertentu
git stash apply stash@{0}

# Drop stash (hapus dari list)
git stash drop stash@{0}

# Apply dan drop stash
git stash pop

# Clear semua stash
git stash clear
```

---

## 👥 Collaboration

### Membuat Pull Request (via CLI)
```bash
# Fork repository (di GitHub web)
# Clone fork Anda
git clone https://github.com/username/fork-repo.git

# Add upstream (original repository)
git remote add upstream https://github.com/original-owner/repo.git

# Sync dengan upstream
git fetch upstream
git merge upstream/main

# Push ke fork Anda
git push origin nama-branch
```

### Tagging
```bash
# Buat tag
git tag v1.0.0

# Buat tag dengan pesan
git tag -a v1.0.0 -m "Version 1.0.0"

# Push tag ke remote
git push origin v1.0.0

# Push semua tag
git push origin --tags

# Hapus tag lokal
git tag -d v1.0.0

# Hapus tag remote
git push origin --delete v1.0.0
```

---

## 🎯 Workflow Umum

### Workflow Sehari-hari
```bash
# 1. Cek status
git status

# 2. Pull update dari remote
git pull

# 3. Buat perubahan
# ... edit file ...

# 4. Add file yang diubah
git add .

# 5. Commit
git commit -m "Pesan commit"

# 6. Push ke remote
git push
```

### Workflow Baru (Feature Branch)
```bash
# 1. Buat branch baru
git checkout -b fitur-baru

# 2. Buat perubahan
# ... edit file ...

# 3. Commit
git add .
git commit -m "Tambah fitur baru"

# 4. Push branch
git push -u origin fitur-baru

# 5. Buat Pull Request di GitHub

# 6. Setelah merge, kembali ke main
git checkout main
git pull

# 7. Hapus branch lokal
git branch -d fitur-baru
```

---

## 🔧 Troubleshooting

### Merge Conflict
```bash
# Lihat conflict
git status

# Edit file yang conflict (cari <<<<<, =====, >>>>)

# Setelah selesai edit:
git add nama-file
git commit

# Atau abort merge
git merge --abort
```

### File Locked
```bash
# Hapus file yang locked
git rm --cached -r nama-folder
git commit -m "Unlock file"
```

### Large File Error
```bash
# Install git-lfs jika belum
git lfs install

# Track large file
git lfs track "*.psd"
git add .gitattributes
git commit -m "Track large files"
```

---

## 📋 Quick Reference

| Command | Deskripsi |
|---------|-----------|
| `git init` | Inisialisasi repository |
| `git clone url` | Clone repository |
| `git status` | Cek status |
| `git add .` | Add semua file |
| `git commit -m "msg"` | Commit |
| `git push` | Push ke remote |
| `git pull` | Pull dari remote |
| `git branch` | Lihat branch |
| `git checkout -b name` | Buat & pindah branch |
| `git merge name` | Merge branch |
| `git rm file` | Hapus file |
| `git log` | Lihat history |
| `git diff` | Lihat perubahan |
| `git stash` | Simpan perubahan sementara |

---

## 📚 Sumber Tambahan

- [Git Documentation](https://git-scm.com/doc)
- [GitHub Git Guide](https://guides.github.com/introduction/git/)
- [Learn Git Branching](https://learngitbranching.js.org/)
- [Git Visual Cheatsheet](https://ndpsoftware.com/git-cheatsheet.html)

---

**Happy Coding! 🚀**
